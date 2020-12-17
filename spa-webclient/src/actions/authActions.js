import {
    STORE_USER,
    USER_SIGNED_OUT,
    USER_EXPIRED,
    STORE_USER_ERROR,
    LOADING_USER
  } from './types'
  import { setAuthHeader } from '../utils/axiosHeaders'
  
  export const storeUser = (user) => {
    setAuthHeader(user.access_token);
    return {
      type: STORE_USER,
      payload: user
    };
  }
  
  export const loadingUser = () => {
    return {
      type: LOADING_USER
    };
  }
  
  export const storeUserError = () => {
    return {
      type: STORE_USER_ERROR
    };
  }
  
  export const userExpired = () => {
    return {
      type: USER_EXPIRED
    };
  }
  
  export const userSignedOut = () => {
    return {
      type: USER_SIGNED_OUT
    };
  }