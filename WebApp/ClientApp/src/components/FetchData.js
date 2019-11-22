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

const FetchData = () => {
  const [carTypes, setCarTypeList] = useState([]);
  const [currentEditedCarType, setCurrentEditedCarType] = useState(new CarType());
  const [isAddCarTypeFormOpened, openAddCarTypeForm] = useState(false);
  const [isEditCarTypeFormOpened, openEditCarTypeForm] = useState(false);

  const createNewCarType = async e => {
    e.preventDefault();
    const form = e.target;
    const data = new FormData(form);
  
    await axios.post("/api/cartype", data).then(() => {
      form.reset();
      setCarTypeList([
        ...carTypes,
        new CarType(data.get("Id"), data.get("Name"), data.get("Seat"), data.get("Cost"))
      ]);
    });
  };

  const editCarType = async e => {
    e.preventDefault();
    const data = new FormData(e.target);
  
    await axios.put("/api/cartype/" + data.get("Id"), data).then(() => {
      openEditCarTypeForm(false);
      const arr = [...carTypes];
      let target = arr.find(el => el.id === data.get("Id"));
      target.name = data.get("Name"); 
      target.seat = data.get("Seat");
      target.cost = data.get("Cost");
      setCarTypeList(arr);
    });
  };

  const confirmDelete = async id => {
    const conf = window.confirm("Do you want to permantly delete item id " + id + " ?");
    if (conf) {
      await axios.delete("/api/cartype/" + id).then(() => {
        const arr = carTypes.filter(el => el.id !== id);
        setCarTypeList(arr);
      });
    }
  };

  const openEditForm = id => {
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
      <Table headers={headers} data={carTypes} hasActionColumn onEditSelected={openEditForm} onDeleteSelected={confirmDelete} />
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
          <form onSubmit={editCarType}>
            <div>
              <input type="hidden" name="Id" defaultValue={currentEditedCarType.id} />
            </div>
            <div>
              <label htmlFor="Name">Name</label>
              <input type="text" name="Name" defaultValue={currentEditedCarType.name} />
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
