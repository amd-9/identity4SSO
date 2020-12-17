import axios from 'axios'

export const setAuthHeader = (token) => {
  axios.defaults.headers.common['Authorization'] = token ? 'Bearer ' + token : ''
};
