import './App.css';
import TaskBlocks from './views/taskBlocks';
import Tasks from './views/tasks';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
          <Route path={"/"} element={<TaskBlocks/>} />
          <Route path={"/tasks/:value"} element={<Tasks/>} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
