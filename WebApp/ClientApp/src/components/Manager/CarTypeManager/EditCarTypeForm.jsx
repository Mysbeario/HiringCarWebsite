import React from "react";
import { Modal, ModalHeader, ModalFooter, ModalBody, Label, Input, FormGroup, Form, Button } from "reactstrap";
import axios from "axios";
import CarType from "../../../types/CarType";

const EditCarTypeForm = ({ isOpen, toggle, onSubmit, item = new CarType() }) => {
	const edit = async e => {
		e.preventDefault();
		const formData = new FormData(e.target);
		await axios.put("api/cartype/" + item.id, formData);
		toggle();
		onSubmit();
	};

	return (
		<Modal isOpen={isOpen} toggle={toggle}>
			<ModalHeader toggle={toggle}>Edit Car Type</ModalHeader>
			<Form onSubmit={edit}>
				<ModalBody>
					<Input type="hidden" name="Id" id="Id" value={item.id} />
					<FormGroup>
						<Label htmlFor="Name">Name</Label>
						<Input type="text" name="Name" id="Name" defaultValue={item.name} />
					</FormGroup>
					<FormGroup>
						<Label htmlFor="Seat">Number of Seat</Label>
						<Input type="number" name="Seat" id="Seat" defaultValue={item.seat} />
					</FormGroup>
					<FormGroup>
						<Label htmlFor="Cost">Cost per Day (VND)</Label>
						<Input type="number" name="Cost" id="Cost" defaultValue={item.cost} />
					</FormGroup>
				</ModalBody>
				<ModalFooter>
					<Button color="primary" type="submit">Edit</Button>
					<Button color="danger" type="reset">Reset</Button>
				</ModalFooter>
			</Form>
		</Modal>
	);
};

export default EditCarTypeForm;