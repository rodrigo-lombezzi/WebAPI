import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import App from './App.jsx'
import './index.css'
import reactDom from "react-dom";

reactDom.render(<App />, document.getElementById("root"));

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <App />
  </StrictMode>,
)
