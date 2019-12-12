import React, { useState, useEffect } from "react";
import { useSelector } from "react-redux";
import axios from "axios";
import {
	Card, CardImg, CardText, CardBody,
	CardTitle, CardSubtitle, Button, CardDeck,
	Container, Row, Col, Form, FormGroup, Input, Label, CustomInput
} from 'reactstrap';
import { Link } from "react-router-dom";
import Pagination from "../Pagination";
import DebounceInput from "../DebounceInput";

const pageSize = 9;

const CarShowRoom = () => {
	const [currentPage, setCurrentPage] = useState(1);
	const [totalPages, setTotalPages] = useState(1);
	const [sortBy, setSorting] = useState("id");
	const [cars, setCarList] = useState([]);
	const [carTypes, setCarTypeList] = useState([]);
	const [carTypeFilter, setCarTypeFilter] = useState(0);
	const [priceRange, setPriceRange] = useState({ min: 0, max: 0 });
	const [seatFilter, setSeatFilter] = useState(0);
	const [isDesc, setOrder] = useState(false);
	const dateFilter = useSelector(state => state.dateFilter);

	const updateData = async () => {
		const { data } = await axios.get(
			`/api/pagination/car/${currentPage}?PageSize=${pageSize}&SortBy=${sortBy}&CarTypeId=${carTypeFilter}&Desc=${isDesc}`
			+ (seatFilter ? `&Seat=${seatFilter}` : "")
			+ (priceRange.min ? `&MinPrice=${priceRange.min}` : "")
			+ (priceRange.max ? `&MaxPrice=${priceRange.max}` : "")
			+ `&PickUpDate=${dateFilter.startDay}` + `&DropOffDate=${dateFilter.endDay}`
		);
		setCarList(data.list);
		setTotalPages(data.totalPages);
	};

	useEffect(() => {
		(async () => {
			const { data } = await axios.get(`/api/cartype`);
			setCarTypeList(data);
		})();
	}, []);

	useEffect(() => {
		updateData();
	}, [currentPage, sortBy, isDesc]);

	useEffect(() => {
		if (currentPage === 1) {
			updateData();
		}
		else {
			setCurrentPage(1);
		}
	}, [carTypeFilter, seatFilter, priceRange])

	const display = () => {
		const arr = [];
		let subArr = [];
		let count = 0;

		for (let i = 0; i < cars.length; i++) {
			if (count === 3) {
				arr.push([...subArr]);
				subArr = [];
				count = 0;
			}
			subArr.push(cars[i]);
			count++;
		}

		if (subArr.length) {
			arr.push([...subArr]);
		}

		return arr.map(sA =>
			<CardDeck style={{ margin: "2em" }}>
				{sA.map(c =>
					<Card>
						<CardImg top width="100%" src={`/api/image/${c.imgPath}`} />
						<CardBody>
							<CardTitle>{c.carTypeName}</CardTitle>
							<CardSubtitle>{c.numberPlate}</CardSubtitle>
							<CardText style={{ color: "orange" }}>
								<h4>{c.cost} VND</h4>
							</CardText>
							<Link to={`/car/${c.id}`}><Button color="info">View More</Button></Link>
						</CardBody>
					</Card>
				)}
			</CardDeck>
		);
	}

	return (
		<Container>
			<Row>
				<Col sm={3}>
					<Form>
						<Row form>
							<Col>
								<FormGroup>
									<CustomInput type="select" onChange={e => setSorting(e.target.value)} >
										<option value="id" defaultValue>Sort by ID</option>
										<option value="cost">Sort by Cost per day</option>
										<option value="carTypeName">Sort by Type</option>
										<option value="seat">Sort by Seat</option>
										<option value="color">Sort by Color</option>
									</CustomInput>
								</FormGroup>
							</Col>
							<Col xs={3}>
								<FormGroup>
									<CustomInput type="switch" id="desc" name="desc" onChange={e => setOrder(e.target.checked)} label="desc" />
								</FormGroup>
							</Col>
						</Row>
						<hr />
						<FormGroup>
							<CustomInput type="select" onChange={e => setCarTypeFilter(e.target.value)}>
								<option value={0} defaultValue>Select Car Type ...</option>
								{carTypes.map(ct => <option value={ct.id}>{ct.name}</option>)}
							</CustomInput>
						</FormGroup>
						<hr />
						<DebounceInput type="number" onInput={(min => setPriceRange({ ...priceRange, min }))} defaultValue={0} label="Min Price" />
						<DebounceInput type="number" onInput={(max => setPriceRange({ ...priceRange, max }))} defaultValue={0} label="Max Price" />
						<hr />
						<FormGroup>
							<Label for="Seat">Seat</Label>
							<Input type="number" id="Seat" name="Seat" defaultValue={0} onChange={e => setSeatFilter(e.target.value)} />
						</FormGroup>
					</Form>
				</Col>
				<Col>
					<Row>
						{display()}
					</Row>
					<Row>
						<Pagination totalPages={totalPages} currentPage={currentPage} onClick={setCurrentPage} />
					</Row>
				</Col>
			</Row>
		</Container>
	);
};

export default CarShowRoom;