import React from "react";
import { Modal, ModalHeader, ModalFooter, ModalBody, Input, Form, Button } from "reactstrap";
import axios from "axios";
import Car from "../../../types/Car";

const DeleteCarTypeForm = ({ isOpen, toggle, onSubmit, item = new Car() }) => {
	const remove = async e => {
		e.preventDefault();
		await axios.delete("api/car/" + item.id);
		toggle();
		onSubmit();
	};

	return (
		<Modal isOpen={isOpen} toggle={toggle}>
			<ModalHeader className="text-danger" toggle={toggle}>Remove Car</ModalHeader>
			<Form onSubmit={remove}>
				<ModalBody>
					<Input type="hidden" name="Id" id="Id" value={item.id} />
					<p className="text-danger">Do you really want to <strong>permantly delete</strong> this item?</p>
					<ul className="text-danger">
						<li><strong>ID:</strong> {item.id}</li>
						<li><strong>Number Plate:</strong> {item.numberPlate}</li>
						<li><strong>Color:</strong> {item.color}</li>
						<li><strong>Type:</strong> {item.carTypeName}</li>
					</ul>
				</ModalBody>
				<ModalFooter>
					<Button color="danger" type="submit">Delete</Button>
					<Button className="text-danger" color="link" onClick={toggle}>Cancel</Button>
				</ModalFooter>
			</Form>
		</Modal>
	);
};

export default DeleteCarTypeForm;