import React, { useState, useEffect, useContext } from "react";
import { Container, Row, Button, Col, Input, FormGroup, Label, CustomInput } from "reactstrap";
import DebounceInput from "../../DebounceInput/DebounceInput";
import CarTable from "./CarTable";
import Pagination from "../../Pagination/Pagination";
import axios from "axios";
import AddCarForm from "./AddCarForm";
import EditCarForm from "./EditCarForm";
import DeleteForm from "./DeleteCarForm";
import { ManagerContext } from "../ManagerHOC";
import ViewDataModal from "./ViewDataModal";

const CarManager = () => {
	const [carTypes, setCarTypeList] = useState([]);
	const [isViewModalOpen, openViewModal] = useState(false);
	const ctx = useContext(ManagerContext);

	const modifyData = (action, id) => {
		ctx.modifyData(action, id);

		if (action === "view") {
			openViewModal(true);
		}
	}

	useEffect(() => {
		(async () => {
			const { data } = await axios.get("/api/cartype");
			const arr = [];
			data.forEach(e => arr.push({ id: e.id, name: e.name }));

			setCarTypeList(arr);
		})();
	}, []);

	return (
		<Container>
			<Row>
				<Col>
					<DebounceInput onInput={ctx.setSearchString} placeholder="Search..." />
				</Col>
				<Col>
					<CustomInput type="select" onChange={e => ctx.setSorting(e.target.value)}>
						<option value="id" defaultValue>Sort by ID</option>
						<option value="numberPlate">Sort by Number Plate</option>
						<option value="carTypeName">Sort by Type</option>
						<option value="color">Sort by Color</option>
					</CustomInput>
				</Col>
				<Col xs={1}>
					<FormGroup>
						<CustomInput type="switch" id="desc" name="desc" onChange={e => ctx.setOrder(e.target.checked)} label="desc" />
					</FormGroup>
				</Col>
			</Row>
			<Row>
				<CarTable data={ctx.entityData} onAction={modifyData} />
			</Row>
			<Row>
				<Button color="primary" onClick={() => ctx.openAddForm(!ctx.isAddFormOpen)}>Add New +</Button>
				<AddCarForm
					isOpen={ctx.isAddFormOpen}
					toggle={() => ctx.openAddForm(!ctx.isAddFormOpen)}
					onSubmit={ctx.updateData}
					carTypeList={carTypes}
				/>
			</Row>
			<Row>
				<Pagination totalPages={ctx.totalPages} currentPage={ctx.currentPage} onClick={ctx.setCurrentPage} />
			</Row>
			<EditCarForm
				isOpen={ctx.isEditFormOpen}
				toggle={() => ctx.openEditForm(!ctx.isEditFormOpen)}
				onSubmit={ctx.updateData}
				item={ctx.findItem(ctx.currentEditedItem)}
				carTypeList={carTypes}
			/>
			<DeleteForm
				isOpen={ctx.isDeleteFormOpen}
				toggle={() => ctx.openDeleteForm(!ctx.isDeleteFormOpen)}
				onSubmit={ctx.updateData}
				item={ctx.findItem(ctx.currentEditedItem)}
			/>
			<ViewDataModal
				isOpen={isViewModalOpen}
				toggle={() => openViewModal(!isViewModalOpen)}
				item={ctx.findItem(ctx.currentEditedItem)}
			/>
		</Container>
	);
};

export default CarManager;