import React from "react";
import { Container, Col, Row, Nav, NavItem, NavLink } from "reactstrap";
import { Link, Route, useRouteMatch, Switch } from "react-router-dom";
import { CarManager, CarTypeManager, BookingManager, UserManager } from "../Manager";

const ManagerLayout = () => {
	const { path, url } = useRouteMatch();

	return (
		<Container>
			<Row>
				<Col xs={2}>
					<h4>Category</h4>
					<hr />
					<Nav vertical>
						<NavItem>
							<NavLink tag={Link} to={`${url}/car-type`}>Car Type</NavLink>
						</NavItem>
						<NavItem>
							<NavLink tag={Link} to={`${url}/car`}>Car</NavLink>
						</NavItem>
						<NavItem>
							<NavLink tag={Link} to={`${url}/booking`}>Booking</NavLink>
						</NavItem>
						<NavItem>
							<NavLink tag={Link} to={`${url}/user`}>User</NavLink>
						</NavItem>
					</Nav>
				</Col>
				<Col>
					<Switch>
						<Route exact path={path}>Welcome</Route>
						<Route path={`${path}/car-type`} component={CarTypeManager} />
						<Route path={`${path}/car`} component={CarManager} />
						<Route path={`${path}/booking`} component={BookingManager} />
						<Route path={`${path}/user`} component={UserManager} />
					</Switch>
				</Col>
			</Row>
		</Container>
	);
};

export default ManagerLayout;