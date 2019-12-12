import React from "react";
import { Modal, ModalHeader, ModalFooter, ModalBody, Label, Input, FormGroup, Form, Button } from "reactstrap";
import axios from "axios";
import Car from "../../../types/Car";

const EditCarForm = ({ isOpen, toggle, onSubmit, item = new Car(), carTypeList }) => {
	const edit = async e => {
		e.preventDefault();
		const formData = new FormData(e.target);
		if (e.target.elements["CarImage"].files.length) {
			formData.append("image", e.target.elements["CarImage"].files[0]);
		}
		await axios.put("api/car/" + item.id, formData);
		toggle();
		onSubmit();
	};

	return (
		<Modal isOpen={isOpen} toggle={toggle}>
			<ModalHeader toggle={toggle}>Edit Car</ModalHeader>
			<Form onSubmit={edit}>
				<ModalBody>
					<Input type="hidden" name="Id" id="Id" value={item.id} />
					<Input type="hidden" name="ImgPath" id="ImgPath" value={item.imgPath} />
					<FormGroup>
						<Label htmlFor="NumberPlate">Number Plate</Label>
						<Input type="text" name="NumberPlate" id="NumberPlate" defaultValue={item.numberPlate} />
					</FormGroup>
					<FormGroup>
						<Label htmlFor="Color">Color</Label>
						<Input type="text" name="Color" id="Color" defaultValue={item.color} />
					</FormGroup>
					<FormGroup>
						<Label htmlFor="CarTypeId">Select Type</Label>
						<Input type="select" name="CarTypeId" id="CarTypeId" defaultValue={item.carTypeId}>
							{carTypeList.map(type => <option value={type.id}>{type.name}</option>)}
						</Input>
					</FormGroup>
					<FormGroup>
						<Label for="CarImage">Image</Label>
						<Input type="file" name="CarImage" id="CarImage" />
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

export default EditCarForm;