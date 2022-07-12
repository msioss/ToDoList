import React from "react";
import { useParams } from "react-router";
import {useState, useEffect} from 'react';

function Tasks(){
    const [tasks,setTask]=useState(null);
    const [isLoaded,setLoaded]=useState(false);
    const { value } = useParams();
    const [name,setName]=useState('');
    const [id,setId]=useState('');

    useEffect(() => {
        fetch('https://localhost:44339/api/Tasks/get-tasks')
            .then((response) => {
                return response.json();
            })
            .then((data) => {
                if (data !== null){
                    var filtered=data.filter((item) => (item.taskBlockId==value));
                    setTask(filtered);
                    setLoaded(true);
                }
            });
      },[]);
      const NameChanged = (event) => {
        setName(event.target.value);
      };
      const IdChanged = (event) => {
        setId(event.target.value);
      };

      const OnCreateSubmit =  (event) => {
        let task={Name:name,Status:false,TaskBlockId:value};
        fetch('https://localhost:44339/api/Tasks/create-task/', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json;charset=utf-8',
            'access-control-allow-origin': '*'
          },
          body: JSON.stringify(task)
        });
      };

      const OnEditSubmit = (event) => {
        fetch("https://localhost:44339/api/Tasks/change-status/" + id, {
          method: "PUT",
          headers: {
            "Content-Type": "application/json;charset=utf-8",
          },
        });
      };
      
      const OnDeleteSubmit = (event) => {
        fetch("https://localhost:44339/api/Tasks/delete-task/" + id, {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json;charset=utf-8",
          },
        });
      };
    return (
      <div>
        <div>
          <form onSubmit={OnCreateSubmit} className="col ">
            Create new task<br></br>
            <label>
              Name:
              <input type="text" onChange={NameChanged} />
            </label>
            <input type="submit" value="Create" />
          </form>
          <form onSubmit={OnEditSubmit} className="col">
            Change status<br></br>
            <label>
              Id:
              <input type="text" onChange={IdChanged} />
            </label>
            
            <input type="submit" value="Edit" />
          </form>
          <form onSubmit={OnDeleteSubmit} className="col forms">
            Delete task<br></br>
            <label>
              Id:
              <input type="text" onChange={IdChanged} />
            </label>
            <input type="submit" value="Delete" />
          </form>
        </div>
        <div className="row">
          {isLoaded ? (
            tasks.map((item) => (
              <div key={item.id} className="border">
                <div>Task id: {item.id}</div>
                <div>Task name: {item.name}</div>
                <div>Task status: {item.status ? "active" : "inactive"}</div>
              </div>
            ))
          ) : (
            <div>Loading...</div>
          )}
        </div>
      </div>
    );
}

export default Tasks;    