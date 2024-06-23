import React from 'react';
import logo from './logo.svg';
import './App.css';
import ComponentOne from './components/ComponentOne'; // Import ComponentOne
import Events from './components/Events'; // Import Events
import Lists from './components/Lists'; // Import Events
import ParentComponent from './components/ParentComponent'; //Import only ParentComponent
import StatefulComponent from './components/StatefulComponent'; //Import for StatefulComponent
import DataFetcher from './components/DataFetcher'; 

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <ComponentOne /> 
        <Events />
        <Lists />
        <ParentComponent/>
        <StatefulComponent/>
        <DataFetcher/>
        {}
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;