import React, { useContext } from "react";
import { Container, Row, Button, Col, Input } from "reactstrap";
import SearchBox from "../SearchBox";
import CarTypeTable from "./CarTypeTable";
import Pagination from "../Pagination";
import AddCarTypeForm from "./AddCarTypeForm";
import EditCarTypeForm from "./EditCarTypeForm";
import DeleteCarTypeForm from "./DeleteCarTypeForm";
import { ManagerContext } from "../ManagerHOC";

const CarTypeManager = () => {
	const ctx = useContext(ManagerContext);

	return (
		<Container>
			<Row>
				<SearchBox onInput={ctx.setSearchString} />
				<Col>
					<Input type="select" onChange={e => ctx.setSorting(e.target.value)}>
						<option value="id" defaultValue>Sort by ID</option>
						<option value="name">Sort by Name</option>
						<option value="seat">Sort by Seat</option>
						<option value="cost">Sort by Cost per day</option>
					</Input>
				</Col>
			</Row>
			<Row>
				<CarTypeTable data={ctx.entityData} onAction={ctx.modifyData} />
			</Row>
			<Row>
				<Button color="primary" onClick={() => ctx.openAddForm(!ctx.isAddFormOpen)}>Add New +</Button>
				<AddCarTypeForm
					isOpen={ctx.isAddFormOpen}
					toggle={() => ctx.openAddForm(!ctx.isAddFormOpen)}
					onSubmit={ctx.updateData}
				/>
			</Row>
			<Row>
				<Pagination totalPages={ctx.totalPages} currentPage={ctx.currentPage} onClick={ctx.setCurrentPage} />
			</Row>
			<EditCarTypeForm
				isOpen={ctx.isEditFormOpen}
				toggle={() => ctx.openEditForm(!ctx.isEditFormOpen)}
				onSubmit={ctx.updateData}
				item={ctx.findItem(ctx.currentEditedItem)}
			/>
			<DeleteCarTypeForm
				isOpen={ctx.isDeleteFormOpen}
				toggle={() => ctx.openDeleteForm(!ctx.isDeleteFormOpen)}
				onSubmit={ctx.updateData}
				item={ctx.findItem(ctx.currentEditedItem)}
			/>
		</Container>
	);
};

export default CarTypeManager;