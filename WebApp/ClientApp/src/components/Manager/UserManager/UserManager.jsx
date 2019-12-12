import React, { useContext } from "react";
import { Container, Row, Button, Col, Input, Label, FormGroup, CustomInput } from "reactstrap";
import DebounceInput from "../../DebounceInput/DebounceInput";
import Pagination from "../../Pagination/Pagination";
import { ManagerContext } from "../ManagerHOC";
import UserTable from "./UserTable";
import DeleteUserForm from "./DeleteUserForm";

const UserManager = () => {
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
							<option value="email">Sort by Email</option>
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
				<UserTable data={ctx.entityData} onAction={ctx.modifyData} />
			</Row>
			<Row>
				<Pagination totalPages={ctx.totalPages} currentPage={ctx.currentPage} onClick={ctx.setCurrentPage} />
			</Row>
			<DeleteUserForm
				isOpen={ctx.isDeleteFormOpen}
				toggle={() => ctx.openDeleteForm(!ctx.isDeleteFormOpen)}
				onSubmit={ctx.updateData}
				item={ctx.findItem(ctx.currentEditedItem)}
			/>
		</Container>
	);
};

export default UserManager;