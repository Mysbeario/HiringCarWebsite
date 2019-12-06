import React, { useState, useEffect } from "react";
import axios from "axios";
import {
	Card, CardImg, CardText, CardBody,
	CardTitle, CardSubtitle, Button, CardDeck
} from 'reactstrap';
import Pagination from "../Pagination";

const pageSize = 9;

const CarShowRoom = () => {
	const [currentPage, setCurrentPage] = useState(1);
	const [totalPages, setTotalPages] = useState(1);
	const [cars, setCarList] = useState([]);

	useEffect(() => {
		(async () => {
			const { data } = await axios.get(`/api/pagination/car/?size=${pageSize}`);
			setTotalPages(data);
		})();
	}, []);

	useEffect(() => {
		(async () => {
			const { data } = await axios.get(`/api/pagination/car/${currentPage}?size=${pageSize}&sortBy=id`);
			setCarList(data);
		})();
	}, [currentPage]);

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
							<CardText></CardText>
							<Button color="info">View More</Button>
						</CardBody>
					</Card>
				)}
			</CardDeck>
		);
	}

	return (
		<div>
			{display()}
			<Pagination totalPages={totalPages} currentPage={currentPage} onClick={setCurrentPage} />
		</div>
	);
};

export default CarShowRoom;