
import './App.css';
import Launcher from './features/launches/Launcher';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import LaunchDetail from './features/launches/LaunchDetail';

function App() {
  return (
    <BrowserRouter>
   
    <div className="App">
     <Routes>
        <Route path='/' index element={ <Launcher/>} />
        <Route path='/launch/:id' element= {<LaunchDetail />} />
        
     </Routes>
     
    </div>
    </BrowserRouter>
  );
}

export default App;
