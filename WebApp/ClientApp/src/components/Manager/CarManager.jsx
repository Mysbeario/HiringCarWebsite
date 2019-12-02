import React, { useState, useEffect } from "react";
import { ModalBody, FormGroup, Label, Input } from "reactstrap";
import Manager from "./Manager";
import TableColumn from "../../types/TableColumn";
import Car from "../../types/Car";
import axios from "axios";

const headers = [
	new TableColumn("id", "ID"),
	new TableColumn("numberPlate", "Number Plate"),
	new TableColumn("color", "Color"),
	new TableColumn("carTypeName", "Type"),
	new TableColumn("carTypeId", "Type ID", true),
	new TableColumn("status", "Status")
];

const CarManager = () => {
	const [currentEditedItem, setCurrentEditedItem] = useState(new Car());
	const [carTypes, setCarTypeList] = useState([]);

	useEffect(() => {
		(async () => {
			const { data } = await axios.get("/api/cartype");
			const arr = [];
			data.forEach(e => arr.push({ id: e.id, name: e.name }));

			setCarTypeList(arr);
		})();
	}, []);

	return (
		<Manager headers={headers} entityName="car" setCurrentEditedEntity={setCurrentEditedItem}>
			<ModalBody>
				<FormGroup>
					<Label htmlFor="Id">ID</Label>
					<Input type="text" name="Id" id="Id" />
				</FormGroup>
				<FormGroup>
					<Label htmlFor="NumberPlate">Number Plate</Label>
					<Input type="text" name="NumberPlate" id="NumberPlate" />
				</FormGroup>
				<FormGroup>
					<Label htmlFor="Color">Color</Label>
					<Input type="text" name="Color" id="Color" />
				</FormGroup>
				<FormGroup>
					<Label htmlFor="CarTypeId">Select Type</Label>
					<Input type="select" name="CarTypeId" id="CarTypeId">
						{carTypes.map(type => <option value={type.id}>{type.name}</option>)}
					</Input>
				</FormGroup>
			</ModalBody>
			<ModalBody>
				<Input type="hidden" name="Id" id="Id" value={currentEditedItem.id} />
				<FormGroup>
					<Label htmlFor="NumberPlate">Number Plate</Label>
					<Input type="text" name="NumberPlate" id="NumberPlate" defaultValue={currentEditedItem.numberPlate} />
				</FormGroup>
				<FormGroup>
					<Label htmlFor="Color">Color</Label>
					<Input type="text" name="Color" id="Color" defaultValue={currentEditedItem.color} />
				</FormGroup>
				<FormGroup>
					<Label htmlFor="CarTypeId">Select Type</Label>
					<Input type="select" name="CarTypeId" id="CarTypeId" defaultValue={currentEditedItem.carTypeId}>
						{carTypes.map(type => <option value={type.id}>{type.name}</option>)}
					</Input>
				</FormGroup>
			</ModalBody>
			<ModalBody>
				<Input type="hidden" name="Id" id="Id" value={currentEditedItem.id} />
				<p className="text-danger">Do you really want to <strong>permantly delete</strong> this item?</p>
				<ul className="text-danger">
					<li><strong>ID:</strong> {currentEditedItem.id}</li>
					<li><strong>Number Plate:</strong> {currentEditedItem.numberPlate}</li>
					<li><strong>Color:</strong> {currentEditedItem.color}</li>
					<li><strong>Type:</strong> {currentEditedItem.carTypeName}</li>
				</ul>
			</ModalBody>
		</Manager>
	);
};

export default CarManager;