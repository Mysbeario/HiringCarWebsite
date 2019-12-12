import React, { useContext } from "react";
import { Container, Row, Col, FormGroup, CustomInput } from "reactstrap";
import DebounceInput from "../../DebounceInput/DebounceInput";
import Pagination from "../../Pagination/Pagination";
import { ManagerContext } from "../ManagerHOC";
import BookingTable from "./BookingTable";
import EditBookingForm from "./EditBookingForm";

const BookingManager = () => {
	const ctx = useContext(ManagerContext);

	return (
		<Container>
			<Row>
				<Col>
					<DebounceInput onInput={ctx.setSearchString} placeholder="Search..." />
				</Col>
				<Col>
					<FormGroup>
						<CustomInput type="select" onChange={e => ctx.setSorting(e.target.value)}>
							<option value="id" defaultValue>Sort by ID</option>
							<option value="date">Sort by Date</option>
							<option value="totalCost">Sort by Total Cost</option>
						</CustomInput>
					</FormGroup>
				</Col>
				<Col xs={1}>
					<FormGroup>
						<CustomInput type="switch" id="desc" name="desc" onChange={e => ctx.setOrder(e.target.checked)} label="desc" />
					</FormGroup>
				</Col>
			</Row>
			<Row>
				<BookingTable data={ctx.entityData} onAction={ctx.modifyData} />
			</Row>
			<Row>
				<Pagination totalPages={ctx.totalPages} currentPage={ctx.currentPage} onClick={ctx.setCurrentPage} />
			</Row>
			<EditBookingForm
				isOpen={ctx.isEditFormOpen}
				toggle={() => ctx.openEditForm(!ctx.isEditFormOpen)}
				onSubmit={ctx.updateData}
				item={ctx.findItem(ctx.currentEditedItem)}
			/>
		</Container>
	);
};

export default BookingManager;