import axios from 'axios';

const getItemsFromApi = async () => {
  const response = await axios.get('http://localhost:5005/items');
  return response.data;
}

export {
  getItemsFromApi
}
