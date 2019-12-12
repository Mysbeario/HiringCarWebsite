class Booking {
	constructor(id = 0, carId = 0, userId = "", pickUpDate = "", dropOffDate = "", pickUpLocation = "", dropOffLocation) {
		this.id = id;
		this.carId = carId;
		this.userId = userId;
		this.pickUpDate = pickUpDate;
		this.dropOffDate = dropOffDate;
		this.pickUpLocation = pickUpLocation;
		this.dropOffLocation = dropOffLocation;
	}
}

export default Booking;
