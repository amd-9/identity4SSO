import React, { useState } from 'react'
import { signoutRedirect } from '../services/userService'
import { useSelector } from 'react-redux'
import * as apiService from '../services/apiService'
import { prettifyJson } from '../utils/jsonUtils'

function Home() {
  const user = useSelector(state => state.auth.user)
  const [itemsData, setItemsData] = useState(null)
  function signOut() {
    signoutRedirect()
  }

  async function getDoughnuts() {
    const items = await apiService.getItemsFromApi()
    setItemsData(items)
  }

  return (
    <div>
      <h1>Home</h1>
      <p>Hello, {user.profile.name}.</p>
      <p>I have given you a token to call your favourite doughnut based API 🍩</p>

      <p>💡 <strong>Tip: </strong><em>Use the Redux dev tools and network tab to inspect what user data was returned from identity and stored in the client.</em></p>

      <button className="button button-outline" onClick={() => getDoughnuts()}>Get items</button>
      <button className="button button-clear" onClick={() => signOut()}>Sign Out</button>

      <pre>
        <code>
          {prettifyJson(itemsData ? itemsData : 'No items yet :(')}
        </code>
      </pre>
    </div>
  )
}

export default Home;
