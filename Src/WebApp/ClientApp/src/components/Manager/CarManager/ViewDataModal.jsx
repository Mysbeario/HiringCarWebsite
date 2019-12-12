import React from "react";
import { Modal, ModalHeader, ModalBody } from "reactstrap";
import Car from "../../../types/Car";

const ViewDataModal = ({ isOpen, toggle, item = new Car() }) => {
	return (
		<Modal isOpen={isOpen} toggle={toggle}>
			<ModalHeader toggle={toggle}>{item.numberPlate}.{item.carTypeName}</ModalHeader>
			<ModalBody>
				<img src={`/api/image/${item.imgPath}`} width="50%" height="50%" />
				<ul>
					<li><strong>ID:</strong> {item.id}</li>
					<li><strong>Number Plate:</strong> {item.numberPlate}</li>
					<li><strong>Color:</strong> {item.color}</li>
					<li><strong>Type:</strong> {item.carTypeName}</li>
				</ul>
			</ModalBody>
		</Modal>
	);
};

export default ViewDataModal;