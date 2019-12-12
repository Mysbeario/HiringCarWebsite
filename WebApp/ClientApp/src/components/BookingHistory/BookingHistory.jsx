import React from "react";
import { Container } from "reactstrap";
import BookingHistoryTable from "./BookingHistoryTable";

const BookingHistory = () => {
    return (
        <Container>
            <h3>Booking history</h3>
            <BookingHistoryTable />
        </Container>
    );
};

export default BookingHistory;