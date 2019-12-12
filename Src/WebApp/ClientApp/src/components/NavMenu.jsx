import React, { useState } from 'react';
import axios from "axios";
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { useSelector, useDispatch } from "react-redux";
import './NavMenu.css';
import { AccountAction } from '../actions';

export const NavMenu = () => {
  const [isCollapsed, collapse] = useState(true);
  const authStatus = useSelector(state => state.account.status);
  const dispatch = useDispatch();

  const toggleNavbar = () => collapse(!isCollapsed);

  const logOut = async () => {
    await axios.post("/api/user/logout");
    dispatch({ type: AccountAction.Reject });
  };

  return (
    <header>
      <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
        <Container>
          <NavbarBrand tag={Link} to="/">Hiring Car</NavbarBrand>
          <NavbarToggler onClick={toggleNavbar} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!isCollapsed} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
              </NavItem>
              {authStatus === "unauthenticated" ?
                <>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/signup">Sign Up</NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/login">Log In</NavLink>
                  </NavItem>
                </> :
                <>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/booking-history">Booking History</NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" onClick={logOut}>Log Out</NavLink>
                  </NavItem>
                </>
              }
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/manager">Manager</NavLink>
              </NavItem>
            </ul>
          </Collapse>
        </Container>
      </Navbar>
    </header>
  );
}
