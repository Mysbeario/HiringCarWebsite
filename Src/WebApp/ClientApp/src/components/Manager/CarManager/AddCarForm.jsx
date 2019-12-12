import React from "react";
import { 
	Modal, ModalHeader, ModalFooter, ModalBody,
	Label, Input, FormGroup, Form, Button, CustomInput
} from "reactstrap";
import axios from "axios";

const AddCarForm = ({ isOpen, toggle, onSubmit, carTypeList }) => {
	const create = async e => {
		e.preventDefault();
		const form = e.target;
		const formData = new FormData(form);
		formData.append("image", form.elements["CarImage"].files[0]);
		await axios.post("api/car", formData);
		form.reset();
		onSubmit();
	};

	return (
		<Modal isOpen={isOpen} toggle={toggle}>
			<ModalHeader toggle={toggle}>Add Car</ModalHeader>
			<Form onSubmit={create}>
				<ModalBody>
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
							{carTypeList.map(type => <option value={type.id}>{type.name}</option>)}
						</Input>
					</FormGroup>
					<FormGroup>
						<Label for="CarImage">Image</Label>
						<CustomInput type="file" id="CarImage" name="CarImage" />
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

export default AddCarForm;