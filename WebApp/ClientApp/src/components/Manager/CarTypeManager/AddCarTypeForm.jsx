import React from "react";
import { Modal, ModalHeader, ModalFooter, ModalBody, Label, Input, FormGroup, Form, Button } from "reactstrap";
import axios from "axios";

const AddCarTypeForm = ({ isOpen, toggle, onSubmit }) => {
	const create = async e => {
		e.preventDefault();
		const form = e.target;
		const formData = new FormData(form);
		await axios.post("api/cartype", formData);
		form.reset();
		onSubmit();
	};

	return (
		<Modal isOpen={isOpen} toggle={toggle}>
			<ModalHeader toggle={toggle}>Add Car Type</ModalHeader>
			<Form onSubmit={create}>
				<ModalBody>
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
	);
};

export default AddCarTypeForm;