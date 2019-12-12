import React, { useEffect } from 'react';
import { Route } from 'react-router';
import axios from "axios";
import { useDispatch } from "react-redux";
import { AccountAction } from "./actions";
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import ManagerLayout from './components/ManagerLayout';
import './custom.css'
import { SignUp, LogIn } from './components/Account';
import CarShowRoom from './components/CarShowRoom';
import CarInfo from './components/CarInfo';
import BookingHistory from './components/BookingHistory';

const App = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    (async () => {
      try {
        await axios.get("/api/user/auth");
        dispatch({ type: AccountAction.Auth });
      }
      catch (e) {
        dispatch({ type: AccountAction.Reject });
      }
    })();
  }, []);

  return (
    <Layout>
      <Route exact path='/' component={Home} />
      <Route path='/signup' component={SignUp} />
      <Route path='/login' component={LogIn} />
      <Route path='/manager' component={ManagerLayout} />
      <Route exact path='/car' component={CarShowRoom} />
      <Route path="/car/:id" component={CarInfo} />
      <Route path="/booking-history" component={BookingHistory} />
    </Layout>
  );
}

export default App;