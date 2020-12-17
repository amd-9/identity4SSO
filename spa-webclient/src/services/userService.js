import { UserManager } from 'oidc-client';
import { storeUserError, storeUser } from '../actions/authActions'

const config = {
    // the URL of our identity server
    authority: process.env.REACT_APP_IDENTITY_SERVICEURL, 
    // this ID maps to the client ID in the identity client configuration
    client_id: process.env.REACT_APP_IDENTITY_CLIENTAPPID, 
    // URL to redirect to after login
    redirect_uri: process.env.REACT_APP_IDENTITY_LOGIN_REDIRECTURL,
    response_type: process.env.REACT_APP_IDENTITY_RESPONSETYPE,
    // the scopes or resources we would like access to
    scope: process.env.REACT_APP_IDENTITY_SCOPE, 
    // URL to redirect to after logout
    post_logout_redirect_uri: process.env.REACT_APP_IDENTITY_LOGOUT_REDIRECTURL, 
  };  

  const userManager = new UserManager(config);

  export const loadUserFromStorage = async (store) => {
    try {
      let user = await userManager.getUser();
      if (!user) { return store.dispatch(storeUserError()); }
      store.dispatch(storeUser(user));
    } catch (e) {
      console.error(`User not found: ${e}`);
      store.dispatch(storeUserError());
    }
  }
  
  export const signinRedirect = () => userManager.signinRedirect(); 
  
  export const signinRedirectCallback = () => userManager.signinRedirectCallback();
  
  export const signoutRedirect = () => {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirect();
  }
  
  export const signoutRedirectCallback = () => {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirectCallback();
  }
  
  export default userManager;
  