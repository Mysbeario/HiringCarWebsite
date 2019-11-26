import React, { useState, useEffect, useRef } from "react";
import axios from "axios";
import { Container, Pagination, PaginationItem, PaginationLink, Modal, ModalHeader, ModalFooter, Row, Form, Col, Input, Button } from "reactstrap";
import Table from "../Table";

const Manager = ({
	headers,
	entityName,
	pageSize = 5,
	setCurrentEditedEntity,
	children
}) => {
	const [entities, setEntityList] = useState([]);
	const [searchString, setSearchString] = useState("");
	const [sortBy, setSorting] = useState(headers[0].name);
	const [currentPage, setCurrentPage] = useState(1);
	const [pages, setTotalPages] = useState(1);
	const [isAddFormOpen, openAddForm] = useState(false);
	const [isEditFormOpen, openEditForm] = useState(false);
	const [isDeleteFormOpen, openDeleteForm] = useState(false);
	const searchTimeout = useRef();

	// Count number of pages used for displaying items
	useEffect(() => {
		(async () => {
			const { data: totalPages } = await axios.get(`/api/pagination/${entityName}/?size=${pageSize}${(searchString.trim() ? "&search=" + searchString : "")}`);
			setTotalPages(totalPages);
		})();
	}, []);

	useEffect(() => {
		(async () => {
			const { data } = await axios.get(`/api/pagination/${entityName}/${currentPage}?size=${pageSize}&sortBy=${sortBy}${(searchString.trim() ? "&search=" + searchString : "")}`);
			setEntityList(data);
		})();
	}, [currentPage, sortBy]);

	// Redirect to the first page when sort by option has been changed
	useEffect(() => {
		setCurrentPage(1);
	}, [sortBy]);

	// Debounce technique, only call API when the user stops typing for a while
	useEffect(() => {
		clearTimeout(searchTimeout.current);
		if (!searchString.trim()) {
			return;
		}

		searchTimeout.current = setTimeout(async () => {
			const { data: totalPages } = await axios.get(`/api/pagination/${entityName}/?size=${pageSize}${(searchString.trim() ? "&search=" + searchString : "")}`);
			setTotalPages(totalPages);
			const { data } = await axios.get(`/api/pagination/${entityName}/1?size=${pageSize}&sortBy=${sortBy}${(searchString.trim() ? "&search=" + searchString : "")}`);
			setEntityList(data);
			// Redirect to the first page
			setCurrentPage(1);
		}, 500)
	}, [searchString]);

	const toggleAddForm = () => openAddForm(!isAddFormOpen);
	const toggleEditForm = () => openEditForm(!isEditFormOpen);
	const toggleDeleteForm = () => openDeleteForm(!isDeleteFormOpen);

	const setupPagination = () => {
		let arr = [];
		for (let i = 1; i <= pages; i++) {
			arr.push(<PaginationItem active={currentPage === i}><PaginationLink onClick={() => setCurrentPage(i)}>{i}</PaginationLink></PaginationItem>);
		}

		return arr;
	};

	const create = async e => {
		e.preventDefault();
		const form = e.target;
		const data = new FormData(form);

		await axios.post(`/api/${entityName}`, data).then(() => {
			form.reset();
			const newEntity = {};
			for (let k of data.keys()) {
				newEntity[k] = data.get(k);
			}
			setEntityList([
				...entities,
				newEntity
			]);
		});
	};

	const edit = async e => {
		e.preventDefault();
		const data = new FormData(e.target);

		await axios.put(`/api/${entityName}/${data.get("Id")}`, data).then(() => {
			openEditForm(false);
			const arr = [...entities];
			let target = arr.find(el => el.id === data.get("Id"));
			for (let k of data.keys()) {
				target[k] = data.get(k);
			}
			setEntityList(arr);
		});
	};

	const remove = async e => {
		e.preventDefault();
		const data = new FormData(e.target);

		await axios.delete(`/api/${entityName}/${data.get("Id")}`).then(() => {
			const arr = entities.filter(el => el.id !== data.get("Id"));
			setEntityList(arr);
			openDeleteForm(false);
		});
	};

	const prepareModifyForm = (id, type) => {
		const data = entities.find(item => item.id === id);
		setCurrentEditedEntity(data);
		if (type === "edit") {
			openEditForm(true);
		} else {
			openDeleteForm(true);
		}
	};

	return (
		<Container>
			<Row>
				<Form>
					<Row>
						<Col>
							<Input type="text" placeholder="Search..." onChange={e => setSearchString(e.target.value)} />
						</Col>
						<Col>
							<Input type="select" onChange={e => setSorting(e.target.value)}>
								{headers.map(header => <option value={header.name}>Sort By {header.display}</option>)}
							</Input>
						</Col>
					</Row>
				</Form>
			</Row>
			<Row>
				<Table headers={headers} data={entities} hasActionColumn onActionSelected={prepareModifyForm} />
			</Row>
			<Row>
				<Button color="primary" onClick={toggleAddForm}>Add New +</Button>
				<Modal isOpen={isAddFormOpen} toggle={toggleAddForm}>
					<ModalHeader toggle={toggleAddForm}>Add New Item</ModalHeader>
					<Form onSubmit={create}>
						{children[0]}
						<ModalFooter>
							<Button color="primary" type="submit">Add</Button>
							<Button color="danger" type="reset">Reset</Button>
						</ModalFooter>
					</Form>
				</Modal>
			</Row>
			<Row>
				<Pagination className="center-pagination">
					{setupPagination()}
				</Pagination>
			</Row>
			<Modal isOpen={isEditFormOpen} toggle={toggleEditForm}>
				<ModalHeader toggle={toggleEditForm}>Edit Item</ModalHeader>
				<Form onSubmit={edit}>
					{children[1]}
					<ModalFooter>
						<Button color="primary" type="submit">Edit</Button>
						<Button color="danger" type="reset">Reset</Button>
					</ModalFooter>
				</Form>
			</Modal>
			<Modal isOpen={isDeleteFormOpen} toggle={toggleDeleteForm}>
				<ModalHeader toggle={toggleDeleteForm} className="text-danger">Delete Item</ModalHeader>
				<Form onSubmit={remove}>
					{children[2]}
					<ModalFooter>
						<Button color="danger" type="submit">Delete</Button>
						<Button className="text-danger" color="link" onClick={toggleDeleteForm}>Cancel</Button>
					</ModalFooter>
				</Form>
			</Modal>
		</Container>
	);
};

export default Manager;