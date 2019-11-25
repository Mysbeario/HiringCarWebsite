import React, { useState, useEffect } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input, Pagination, PaginationItem, PaginationLink } from "reactstrap";
import Table from "./Table";
import axios from "axios";
import TableColumn from '../types/TableColumn';
import CarType from "../types/CarType";

const pageSize = 5;

const headers = [
  new TableColumn("id", "ID"),
  new TableColumn("name", "Type"),
  new TableColumn("seat", "Seat"),
  new TableColumn("cost", "Cost (VND per day)")
];

const CarTypeManager = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const [carTypes, setCarTypeList] = useState([]);
  const [pages, setTotalPages] = useState(1);
  const [currentEditedCarType, setCurrentEditedCarType] = useState(new CarType());
  const [isAddCarTypeFormOpen, setAddCarTypeForm] = useState(false);
  const [isEditCarTypeFormOpen, setEditCarTypeForm] = useState(false);
  const [isDeleteCarTypeFormOpen, setDeleteCarTypeForm] = useState(false);

  const toggleAddCarTypeModal = () => setAddCarTypeForm(!isAddCarTypeFormOpen);
  const toggleEditCarTypeModal = () => setEditCarTypeForm(!isEditCarTypeFormOpen);
  const toggleDeleteCarTypeModal = () => setDeleteCarTypeForm(!isDeleteCarTypeFormOpen);

  useEffect(() => {
    (async () => {
      const { data: totalPages } = await axios.get("/api/pagination/cartype/?size=" + pageSize);
      setTotalPages(totalPages);
    })();
  }, []);

  useEffect(() => {
    (async () => {
      const { data } = await axios.get("/api/pagination/cartype/" + currentPage + "?size=" + pageSize);
      setCarTypeList(data);
    })();
  }, [currentPage]);

  const setupPagination = () => {
    let arr = [];
    for (let i = 1; i <= pages; i++) {
      arr.push(<PaginationItem active={currentPage === i}><PaginationLink onClick={() => setCurrentPage(i)}>{i}</PaginationLink></PaginationItem>);
    }
  
    return arr;
  }

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
      setEditCarTypeForm(false);
      const arr = [...carTypes];
      let target = arr.find(el => el.id === data.get("Id"));
      target.name = data.get("Name");
      target.seat = data.get("Seat");
      target.cost = data.get("Cost");
      setCarTypeList(arr);
    });
  };

  const deleteCarType = async e => {
    e.preventDefault();
    const data = new FormData(e.target);

    await axios.delete("/api/cartype/" + data.get("Id")).then(() => {
      const arr = carTypes.filter(el => el.id !== data.get("Id"));
      setCarTypeList(arr);
      setDeleteCarTypeForm(false);
    });
  };

  const openEditForm = id => {
    const data = carTypes.find(item => item.id === id);
    setCurrentEditedCarType(data);
    toggleEditCarTypeModal();
  };

  const openDeleteForm = id => {
    const data = carTypes.find(item => item.id === id);
    setCurrentEditedCarType(data);
    toggleDeleteCarTypeModal();
  };

  return (
    <div>
      <Table headers={headers} data={carTypes} hasActionColumn onEditSelected={openEditForm} onDeleteSelected={openDeleteForm} />
      <div>
        <Button color="primary" onClick={toggleAddCarTypeModal}>Add New Car Type</Button>
        <Modal isOpen={isAddCarTypeFormOpen} toggle={toggleAddCarTypeModal}>
          <ModalHeader toggle={toggleAddCarTypeModal}>Add New Car Type</ModalHeader>
          <Form onSubmit={createNewCarType}>
            <ModalBody>
              <FormGroup>
                <Label htmlFor="Id">ID</Label>
                <Input type="text" name="Id" id="Id" />
              </FormGroup>
              <FormGroup>
                <Label htmlFor="Name">Name</Label>
                <Input type="text" name="Name" id="Name" />
              </FormGroup>
              <FormGroup>
                <Label htmlFor="Seat">Number of Seat</Label>
                <Input type="number" name="Seat" id="Seat" />
              </FormGroup>
              <FormGroup>
                <Label htmlFor="Cost">Cost per Day (VND)</Label>
                <Input type="number" name="Cost" id="Cost" />
              </FormGroup>
            </ModalBody>
            <ModalFooter>
              <Button color="primary" type="submit">Add</Button>
              <Button color="danger" type="reset">Reset</Button>
            </ModalFooter>
          </Form>
        </Modal>
      </div>
      <Pagination>
        {setupPagination()}
      </Pagination>
      <Modal isOpen={isEditCarTypeFormOpen} toggle={toggleEditCarTypeModal}>
        <ModalHeader toggle={toggleEditCarTypeModal}>Edit Car Type</ModalHeader>
        <Form onSubmit={editCarType}>
          <ModalBody>
            <Input type="hidden" name="Id" id="Id" value={currentEditedCarType.id} />
            <FormGroup>
              <Label htmlFor="Name">Name</Label>
              <Input type="text" name="Name" id="Name" defaultValue={currentEditedCarType.name} />
            </FormGroup>
            <FormGroup>
              <Label htmlFor="Seat">Number of Seat</Label>
              <Input type="number" name="Seat" id="Seat" defaultValue={currentEditedCarType.seat} />
            </FormGroup>
            <FormGroup>
              <Label htmlFor="Cost">Cost per Day (VND)</Label>
              <Input type="number" name="Cost" id="Cost" defaultValue={currentEditedCarType.cost} />
            </FormGroup>
          </ModalBody>
          <ModalFooter>
            <Button color="primary" type="submit">Edit</Button>
            <Button color="danger" type="reset">Reset</Button>
          </ModalFooter>
        </Form>
      </Modal>
      <Modal isOpen={isDeleteCarTypeFormOpen} toggle={toggleDeleteCarTypeModal}>
        <ModalHeader toggle={toggleDeleteCarTypeModal} className="text-danger">Delete Car Type</ModalHeader>
        <Form onSubmit={deleteCarType}>
          <ModalBody>
            <Input type="hidden" name="Id" id="Id" value={currentEditedCarType.id} />
            <p className="text-danger">Do you really want to <strong>permantly delete</strong> this item?</p>
            <ul className="text-danger">
              <li><strong>ID:</strong> {currentEditedCarType.id}</li>
              <li><strong>Name:</strong> {currentEditedCarType.name}</li>
              <li><strong>Seat:</strong> {currentEditedCarType.seat}</li>
              <li><strong>Cost per Day:</strong> {currentEditedCarType.cost} VND</li>
            </ul>
          </ModalBody>
          <ModalFooter>
            <Button color="danger" type="submit">Delete</Button>
            <Button className="text-danger" color="link" onClick={toggleDeleteCarTypeModal}>Cancel</Button>
          </ModalFooter>
        </Form>
      </Modal>
    </div>
  );
};

export default CarTypeManager;
