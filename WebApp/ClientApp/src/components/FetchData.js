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
          <form>
            <div>
              <label>ID</label>
              <input type="text"></input>
            </div>
            <div>
              <label>Name</label>
              <input type="text"></input>
            </div>
            <div>
              <label>Number of Seat</label>
              <input type="text"></input>
            </div>
            <div>
              <label>Cost per Day (VND)</label>
              <input type="text"></input>
            </div>
          </form>
        </Modal>}
    </div>
  );
};

export default FetchData;
