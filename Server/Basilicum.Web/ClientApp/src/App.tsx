import * as React from 'react';
import './App.css';

import logo from './logo.svg';
import ParameterSelector from './Parameter/ParameterSelector';

class App extends React.Component {
  public render() {
    return (
      <div className="App">
      <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet"/>
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro">
          To get started, edit <code>src/App.tsx</code> and save to reload.
        </p>
        <ParameterSelector />
      </div>
    );
  }
}

export default App;
