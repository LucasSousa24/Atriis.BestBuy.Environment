import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import { BrowserRouter } from "react-router-dom"
// Bootstrap CSS
import "bootstrap/dist/css/bootstrap.min.css";
// Bootstrap Bundle JS
import "bootstrap/dist/js/bootstrap.bundle.min";

ReactDOM.createRoot(document.getElementById('app-root')).render(
<BrowserRouter>
  <App/>
</BrowserRouter>
);
