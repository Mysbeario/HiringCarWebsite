import React, { useState, useEffect } from 'react';
import Table from "./Table";
import axios from "axios";
import TableColumn from '../types/TableColumn';
import CarType from "../types/CarType";
import Modal from './Modal';

const headers = [
  new TableColumn("id", "ID"),
  new TableColumn("name", "Type"),
  new TableColumn("seat", "Seat"),
  new TableColumn("cost", "Cost (VND per day)")
];

const createNewCarType = async e => {
  e.preventDefault();
  const data = new FormData(e.target);
  
  await axios.post("/api/cartype", data);
};

const FetchData = () => {
  const [carTypes, setCarTypeList] = useState([]);
  const [currentEditedCarType, setCurrentEditedCarType] = useState(new CarType());
  const [isAddCarTypeFormOpened, openAddCarTypeForm] = useState(false);
  const [isEditCarTypeFormOpened, openEditCarTypeForm] = useState(false);

  const editCarType = id => {
    const data = carTypes.find(item => item.id === id);
    setCurrentEditedCarType(data);
    openEditCarTypeForm(true);
  };

  useEffect(() => {
    (async () => {
      const { data } = await axios.get("/api/cartype");
      setCarTypeList(data);
    })();
  }, []);

  return (
    <div>
      <Table headers={headers} data={carTypes} hasActionColumn onEditSelected={editCarType} />
      <button onClick={() => openAddCarTypeForm(true)}>Add new Car Type</button>
      {isAddCarTypeFormOpened &&
        <Modal title="Add new Car Type" onClose={() => openAddCarTypeForm(false)}>
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
              <button type="reset">Reset</button>
            </div>
          </form>
        </Modal>}
        {isEditCarTypeFormOpened && 
        <Modal title="Edit Car Type" onClose={() => openEditCarTypeForm(false)}>
          <form>
            <div>
              <input type="hidden" name="Id" value={currentEditedCarType.id} />
            </div>
            <div>
              <label htmlFor="Name">Name</label>
              <input type="text" name="Name" defaultValue={currentEditedCarType.name}/>
            </div>
            <div>
              <label htmlFor="Seat">Number of Seat</label>
              <input type="number" name="Seat" defaultValue={currentEditedCarType.seat} />
            </div>
            <div>
              <label htmlFor="Cost">Cost per Day (VND)</label>
              <input type="number" name="Cost" defaultValue={currentEditedCarType.cost} />
            </div>
            <div>
              <button type="submit">Edit</button>
              <button type="reset">Reset</button>
            </div>
          </form>
        </Modal>}
    </div>
  );
};

export default FetchData;
