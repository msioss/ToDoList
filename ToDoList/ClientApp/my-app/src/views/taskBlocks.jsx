import React from "react";
import {useState, useEffect} from 'react';

function TaskBlocks() {
    const [list,setList]=useState(null);
    const [isLoaded,setLoaded]=useState(false);
    const [name,setName]=useState('');
    const [id,setId]=useState('');

    useEffect(() => {
        fetch('https://localhost:44339/api/TaskBlocks/get-blocks')
            .then((response) => {
                return response.json();
            })
            .then((data) => {
                if (data !== null)
                    setList(data);
                    setLoaded(true);
            });
      },[])

      const NameChanged = (event) => {
        setName(event.target.value);
      };
      const IdChanged = (event) => {
        setId(event.target.value);
      };
      const OnCreateSubmit =  (event) => {
        fetch('https://localhost:44339/api/TaskBlocks/create-block', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json;charset=utf-8'
          },
          body: JSON.stringify({Name:name})
        });
      };

      const OnEditSubmit = (event) => {
        fetch('https://localhost:44339/api/TaskBlocks/change-name', {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json;charset=utf-8'
          },
          body: JSON.stringify({Id:id,Name:name})
        });
      };
      
      const OnDeleteSubmit = (event) => {
        fetch('https://localhost:44339/api/TaskBlocks/delete-block/'+id, {
          method: 'DELETE',
          headers: {
            'Content-Type': 'application/json;charset=utf-8'
          }
        });
      };

      return (
        <div>
          <div>
            <form onSubmit={OnCreateSubmit} className="col ">
              Create new block<br></br>
              <label>
                Name:
                <input type="text" onChange={NameChanged}/>
              </label>
              <input type="submit" value="Create" />
            </form>
            <form onSubmit={OnEditSubmit} className="col">
              Rename block<br></br>
              <label>
                Id:
                <input type="text" onChange={IdChanged}/>
              </label>
              <label>
                New name:
                <input type="text" onChange={NameChanged}/>
              </label>
              <input type="submit" value="Edit" />
            </form>
            <form onSubmit={OnDeleteSubmit} className="col forms" >
              Delete block<br></br>
              <label>
                Id:
                <input type="text" onChange={IdChanged}/>
              </label>
              
              <input type="submit" value="Delete" />
            </form>
          </div>
          <div className="row">
            {isLoaded ? (
              list.map((item) => (
                <div key={item.id} className="border">
                  id - {item.id}
                  <br></br>
                  name - {item.name}
                  <br></br>
                </div>
              ))
            ) : (
              <div>Loading...</div>
            )}
          </div>
        </div>
      );
    
}
export default TaskBlocks;  