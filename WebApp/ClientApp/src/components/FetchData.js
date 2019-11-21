import React, { useState, useEffect } from 'react';
import Table from "./Table";
import axios from "axios";
import TableColumn from '../types/TableColumn';

const headers = [
  new TableColumn("id", "ID"),
  new TableColumn("name", "Type"),
  new TableColumn("seat", "Seat"),
  new TableColumn("cost", "Cost (VND per day)")
];

const FetchData = () => {
  const [carTypes, setData] = useState([]);

  useEffect(() => {
    (async () => {
      const { data } = await axios.get("/api/cartype");
      setData(data);
    })();
  }, []);

  return (
    <div>
      <Table headers={headers} data={carTypes} />
      <button>Add new Car Type</button>
    </div>
  );
};

export default FetchData;
