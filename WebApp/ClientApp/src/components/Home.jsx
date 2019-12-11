import React from 'react';
import { Label, Input, Form, Button, FormGroup, Row, Col } from "reactstrap";
import { nowToString } from '../utilities';

export const Home = () => {
  return (
    <div>
      <Form>
        <Row form>
          <Col>
            <FormGroup>
              <Label>Pick-up Date</Label>
              <Input type="date" min={nowToString()} />
            </FormGroup>
          </Col>
          <Col>
            <FormGroup>
              <Label>Drop-off Date</Label>
              <Input type="date" />
            </FormGroup>
          </Col>
          <Col xs={2}>
            <FormGroup>
              <Label>&nbsp;</Label><br/>
              <Button color="success" type="submit">Find Car</Button>
            </FormGroup>
          </Col>
        </Row>
      </Form>
    </div>
  );
};
