import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import ManagerLayout from './components/ManagerLayout';
import './custom.css'
import SignUp from './components/SignUp';
import CarShowRoom from './components/CarShowRoom';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/signup' component={SignUp} />
        <Route path='/manager' component={ManagerLayout} />
        <Route path='/car' component={CarShowRoom} />
      </Layout>
    );
  }
}
