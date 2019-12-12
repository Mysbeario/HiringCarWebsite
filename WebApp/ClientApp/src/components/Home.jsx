import React from 'react';
import { useDispatch } from "react-redux";
import { Link } from "react-router-dom";
import { Label, Input, Form, Button, FormGroup, Row, Col } from "reactstrap";
import { nowToString } from '../utilities';
import { setStartDay, setEndDay } from '../actions';

export const Home = () => {
  const dispatch = useDispatch();
  return (
    <div>
      <Form>
        <Row form>
          <Col>
            <FormGroup>
              <Label>Pick-up Date</Label>
              <Input type="date" min={nowToString()} onChange={e => dispatch(setStartDay(e.target.value))} />
            </FormGroup>
          </Col>
          <Col>
            <FormGroup>
              <Label>Drop-off Date</Label>
              <Input type="date" onChange={e => dispatch(setEndDay(e.target.value))} />
            </FormGroup>
          </Col>
          <Col xs={2}>
            <FormGroup>
              <Label>&nbsp;</Label><br/>
              <Link to="/car"><Button color="success">Find Car</Button></Link>
            </FormGroup>
          </Col>
        </Row>
      </Form>
    </div>
  );
};
