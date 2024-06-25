import React from 'react';
import logo from './logo.svg';
import './App.css';
import ComponentOne from './Components/ComponentOne';
import Events from './Components/Events';
import MyForm from './Components/CoEvents';
import Lists from './Components/Lists';
import ParentComponent from './Components/ParentComponent';
import StatefulComponent from './Components/StatefulComponent';
import DataFetcher from './Components/DataFetcher';

function App() {
  return (
    <div className="App">
      

        <ComponentOne />
        <Events />
        <MyForm/>
        <Lists/>
        <ParentComponent/>
        <StatefulComponent/>
        <DataFetcher/>
        {}
      
    </div>
  );
}

export default App;
