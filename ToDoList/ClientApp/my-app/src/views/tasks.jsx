import React from "react";
import { useParams } from "react-router";
import {useState, useEffect} from 'react';

function Tasks(){
    const [tasks,setTask]=useState(null);
    const [isLoaded,setLoaded]=useState(false);
    const { value } = useParams();
    useEffect(() => {
        fetch('https://localhost:44339/api/Tasks/get-tasks')
            .then((response) => {
                return response.json();
            })
            .then((data) => {
                if (data !== null){
                    var filtered=data.filter((item) => (item.taskBlockId==value));
                    console.log(filtered);
                    setTask(filtered);
                    setLoaded(true);
                }
            });
      },[]);
    return (
        <div className="row">
        {
        isLoaded
        ? tasks.map((item) => (
        <div key={item.id} className="border">
            <div>Task id: {item.id}</div>
            <div>Task name: {item.name}</div>
            <div>Task status: {item.status?"true":"false"}</div>
        </div>
        ))
        : <div>Loading...</div>}
        </div>
    );
}

export default Tasks;    