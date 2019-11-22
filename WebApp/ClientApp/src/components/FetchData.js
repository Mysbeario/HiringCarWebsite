import React, { useState, useEffect } from 'react';
import Table from "./Table";
import axios from "axios";
import TableColumn from '../types/TableColumn';
import Modal from './Modal/Modal';

const headers = [
  new TableColumn("id", "ID"),
  new TableColumn("name", "Type"),
  new TableColumn("seat", "Seat"),
  new TableColumn("cost", "Cost (VND per day)")
];

const createNewCarType = e => {
  e.preventDefault();
  const data = new FormData(e.target);
  
  axios.post("/api/cartype", data);
};

const FetchData = () => {
  const [carTypes, setData] = useState([]);
  const [isAddCarTypeFormOpened, openAddCarTypeForm] = useState(false);

  useEffect(() => {
    (async () => {
      const { data } = await axios.get("/api/cartype");
      setData(data);
    })();
  }, []);

  return (
    <div>
      <Table headers={headers} data={carTypes} />
      <button onClick={() => openAddCarTypeForm(true)}>Add new Car Type</button>
      {isAddCarTypeFormOpened &&
        <Modal onClose={() => openAddCarTypeForm(false)}>
          <form onSubmit={createNewCarType}>
            <div>
              <label htmlFor="Id">ID</label>
              <input type="text" name="Id" />
            </div>
            <div>
              <label htmlFor="Name">Name</label>
              <input type="text" name="Name" />
            </div>
            <div>
              <label htmlFor="Seat">Number of Seat</label>
              <input type="number" name="Seat" />
            </div>
            <div>
              <label htmlFor="Cost">Cost per Day (VND)</label>
              <input type="number" name="Cost" />
            </div>
            <div>
              <button type="submit">Add</button>
              <button>Reset</button>
            </div>
          </form>
        </Modal>}
    </div>
  );
};

export default FetchData;
