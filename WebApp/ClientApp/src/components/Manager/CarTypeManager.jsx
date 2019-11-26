import React, { useState } from "react";
import { ModalBody, FormGroup, Label, Input } from "reactstrap";
import Manager from "./Manager";
import CarType from "../../types/CarType";
import TableColumn from "../../types/TableColumn";

const headers = [
  new TableColumn("id", "ID"),
  new TableColumn("name", "Type"),
  new TableColumn("seat", "Seat"),
  new TableColumn("cost", "Cost (VND per day)")
];

const CarTypeManager = () => {
	const [currentEditedItem, setCurrentEditedItem] = useState(new CarType());
	return (
		<Manager headers={headers} entityName="cartype" setCurrentEditedEntity={setCurrentEditedItem}>
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
			<ModalBody>
				<Input type="hidden" name="Id" id="Id" value={currentEditedItem.id} />
				<FormGroup>
					<Label htmlFor="Name">Name</Label>
					<Input type="text" name="Name" id="Name" defaultValue={currentEditedItem.name} />
				</FormGroup>
				<FormGroup>
					<Label htmlFor="Seat">Number of Seat</Label>
					<Input type="number" name="Seat" id="Seat" defaultValue={currentEditedItem.seat} />
				</FormGroup>
				<FormGroup>
					<Label htmlFor="Cost">Cost per Day (VND)</Label>
					<Input type="number" name="Cost" id="Cost" defaultValue={currentEditedItem.cost} />
				</FormGroup>
			</ModalBody>
			<ModalBody>
				<Input type="hidden" name="Id" id="Id" value={currentEditedItem.id} />
				<p className="text-danger">Do you really want to <strong>permantly delete</strong> this item?</p>
				<ul className="text-danger">
					<li><strong>ID:</strong> {currentEditedItem.id}</li>
					<li><strong>Name:</strong> {currentEditedItem.name}</li>
					<li><strong>Seat:</strong> {currentEditedItem.seat}</li>
					<li><strong>Cost per Day:</strong> {currentEditedItem.cost} VND</li>
				</ul>
			</ModalBody>
		</Manager>
	);
};

export default CarTypeManager;