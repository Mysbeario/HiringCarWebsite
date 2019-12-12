import React, {useEffect, useState} from "react";
import { Table } from "reactstrap";
import axios from "axios";
import { useHistory } from "react-router-dom";
import Pagination from "../Pagination/Pagination";

const BookingHistoryTable = () => {
	const [data, setData] = useState([]);
	const history = useHistory();
	const [currentPage, setCurrentPage] = useState(1);
	const [totalPages, setTotalPages] = useState(1);

	useEffect(() => {
		(async () => {
			try {
				await axios.get("/api/user/auth");
				const { data: fetchData } = await axios.get(`api/pagination/booking/${currentPage}?PageSize=10&ByUser=true`);
				setTotalPages(fetchData.totalPages);
				setData(fetchData.list);
			}
			catch (e) {
				history.push("/login");
			}
		})();
	}, [currentPage]);

	return (
		<>
		<Table striped>
			<thead>
				<tr>
					<th>Car Number Plate</th>
					<th>Pick Up Date</th>
					<th>Drop Off Date</th>
					<th>Pick Up Location</th>
					<th>Drop Off Location</th>
					<th>Total Cost (VND)</th>
					<th>Status</th>
				</tr>
			</thead>
			<tbody>
				{data.map(item => <tr>
					<td>{item.numberPlate}</td>
					<td>{item.pickUpDate}</td>
					<td>{item.dropOffDate}</td>
					<td>{item.pickUpLocation}</td>
					<td>{item.dropOffLocation}</td>
					<td>{item.totalCost}</td>
					<td>{item.status}</td>
				</tr>)}
			</tbody>
		</Table>
		<Pagination currentPage={currentPage} totalPages={totalPages} onClick={setCurrentPage} />
		</>
	);
};

export default BookingHistoryTable;