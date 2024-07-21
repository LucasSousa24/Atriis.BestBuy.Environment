import { Link } from "react-router-dom";
import React from 'react';
import useNavbar from "./useNavbar";

const Navbar = () => {
  const {
    activeNavBar
  } = useNavbar();

  return (
    <>
      <nav className="navbar sticky-top navbar-expand-lg bg-body-tertiary" data-bs-theme="dark">
          <div className="container-fluid">
            <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
              <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse justify-content-end" id="navbarNavAltMarkup">
              <div className="navbar-nav">
                  <Link className={`nav-link ${activeNavBar === 1 ? "active" : ""}`} to="/">Home</Link>
                  <Link className={`nav-link ${activeNavBar === 2 ? "active" : ""}`} to="/products">Products</Link>
              </div>
            </div>
          </div>
      </nav>
    </>
  )
}

export default Navbar
