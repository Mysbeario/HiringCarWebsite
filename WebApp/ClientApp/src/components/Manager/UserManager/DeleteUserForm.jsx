import React from "react";
import { Modal, ModalHeader, ModalFooter, ModalBody, Input, Form, Button } from "reactstrap";
import axios from "axios";
import User from "../../../types/User";

const DeleteUserForm = ({ isOpen, toggle, onSubmit, item = new User() }) => {
	const remove = async e => {
		e.preventDefault();
		await axios.delete("api/user/" + item.id);
		toggle();
		onSubmit();
	};

	return (
		<Modal isOpen={isOpen} toggle={toggle}>
			<ModalHeader className="text-danger" toggle={toggle}>Remove User</ModalHeader>
			<Form onSubmit={remove}>
				<ModalBody>
					<Input type="hidden" name="Id" id="Id" value={item.id} />
					<p className="text-danger">
						Do you really want to <strong>permantly delete</strong> this item?
					</p>
					<ul className="text-danger">
						<li><strong>ID:</strong> {item.id}</li>
						<li><strong>Email:</strong> {item.email}</li>
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

export default DeleteUserForm;