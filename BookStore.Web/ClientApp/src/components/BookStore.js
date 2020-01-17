import React, { Component } from 'react';
import axios from 'axios';
import { Input, FormGroup, Label, Modal, ModalHeader, ModalBody, ModalFooter, Table, Button } from 'reactstrap';

export class BookStore extends Component {
    state = {
        books: [],
        newBookData: {
            isbn: '',
            title: '',
            publisher: '',
            price: 0,
            availableStock: 0
        },
        editBookData: {
            id: '',
            isbn: '',
            title: '',
            publisher: '',
            price: 0,
            availableStock: 0
        },
        newBookModal: false,
        editBookModal: false
    }
    componentWillMount() {
        this._refreshBooks();
    }
    toggleNewBookModal() {
        this.setState({
            newBookModal: !this.state.newBookModal
        });
    }
    toggleEditBookModal() {
        this.setState({
            editBookModal: !this.state.editBookModal
        });
    }
    addBook() {
        axios.post('http://localhost:49991/api/Book/v1/books', this.state.newBookData).then((response) => {
            let { books } = this.state;
            debugger;
            //books.push(response.data);
            books.push(this.state.newBookData);

            this.setState({
                books, newBookModal: false, newBookData: {
                    isbn: '',
                    title: '',
                    publisher: '',
                    price: 0,
                    availableStock: 0
                }
            });
        });
    }
    updateBook() {
        let {id, isbn, title, publisher, price, availableStock} = this.state.editBookData;
        debugger;
        axios.put('http://localhost:49991/api/Book/v1/books/' + this.state.editBookData.id, {
           id, isbn, title, publisher, price, availableStock
        }).then((response) => {
            this._refreshBooks();

            this.setState({
                editBookModal: false, editBookData: { id: '', isbn: '', title: '', publisher: '', price: 0, availableStock: 0 }
            })
        });
    }
    editBook(id, isbn, title, publisher, price, availableStock) {
        this.setState({
            editBookData: { id, isbn, title, publisher, price, availableStock }, editBookModal: !this.state.editBookModal
        });
    }
    deleteBook(id) {
        axios.delete('http://localhost:49991/api/Book/v1/books/' + id).then((response) => {
            this._refreshBooks();
        });
    }
    _refreshBooks() {
        axios.get('http://localhost:49991/api/Book/v1/books').then((response) => {
          
            this.setState({
                books: response.data
            })
        });
    }
    render() {
        let books = this.state.books.map((book) => {
           
            return (
                <tr key={book.id}>
                    <td>{book.id}</td>
                    <td>{book.isbn}</td>
                    <td>{book.title}</td>
                    <td>{book.publisher}</td>
                    <td>{book.price}</td>
                    <td>{book.availableStock}</td>
                    <td>
                        <Button color="success" size="sm" className="mr-2" onClick={this.editBook.bind(this, book.id, book.isbn, book.title, book.publisher, book.price, book.availableStock)}>Edit</Button>
                        <Button color="danger" size="sm" onClick={this.deleteBook.bind(this, book.id)}>Delete</Button>
                    </td>
                </tr>
            )
        });
        return (
            <div className="App container">

                <h1>Book Store</h1>

                <Button className="my-3" color="primary" onClick={this.toggleNewBookModal.bind(this)}>Add Book</Button>

                <Modal isOpen={this.state.newBookModal} toggle={this.toggleNewBookModal.bind(this)}>
                    <ModalHeader toggle={this.toggleNewBookModal.bind(this)}>Add a new book</ModalHeader>
                    <ModalBody>
                        <FormGroup>
                            <Label for="isbn">Isbn</Label>
                            <Input id="isbn" value={this.state.newBookData.isbn} onChange={(e) => {
                                let { newBookData } = this.state;

                                newBookData.isbn = e.target.value;

                                this.setState({ newBookData });
                            }} />
                        </FormGroup>
                        <FormGroup>
                            <Label for="title">Title</Label>
                            <Input id="title" value={this.state.newBookData.title} onChange={(e) => {
                                let { newBookData } = this.state;

                                newBookData.title = e.target.value;

                                this.setState({ newBookData });
                            }} />
                        </FormGroup>
                        <FormGroup>
                            <Label for="publisher">Publisher</Label>
                            <Input id="publisher" value={this.state.newBookData.publisher} onChange={(e) => {
                                let { newBookData } = this.state;

                                newBookData.publisher = e.target.value;

                                this.setState({ newBookData });
                            }} />
                        </FormGroup>
                        <FormGroup>
                            <Label for="price">Price</Label>
                            <Input id="price" value={this.state.newBookData.price} onChange={(e) => {
                                let { newBookData } = this.state;

                                newBookData.price = e.target.value;

                                this.setState({ newBookData });
                            }} />
                        </FormGroup>
                        <FormGroup>
                            <Label for="availableStock">Available Stock</Label>
                            <Input id="availableStock" value={this.state.newBookData.availableStock} onChange={(e) => {
                                let { newBookData } = this.state;

                                newBookData.availableStock = e.target.value;

                                this.setState({ newBookData });
                            }} />
                        </FormGroup>

                    </ModalBody>
                    <ModalFooter>
                        <Button color="primary" onClick={this.addBook.bind(this)}>Add Book</Button>{' '}
                        <Button color="secondary" onClick={this.toggleNewBookModal.bind(this)}>Cancel</Button>
                    </ModalFooter>
                </Modal>

                <Modal isOpen={this.state.editBookModal} toggle={this.toggleEditBookModal.bind(this)}>
                    <ModalHeader toggle={this.toggleEditBookModal.bind(this)}>Edit a new book</ModalHeader>
                    <ModalBody>
                        <FormGroup>
                            <Label for="isbn">Isbn</Label>
                            <Input id="isbn" value={this.state.editBookData.isbn} onChange={(e) => {
                                let { editBookData } = this.state;

                                editBookData.isbn = e.target.value;

                                this.setState({ editBookData });
                            }} />
                        </FormGroup>
                        <FormGroup>
                            <Label for="title">Title</Label>
                            <Input id="title" value={this.state.editBookData.title} onChange={(e) => {
                                let { editBookData } = this.state;

                                editBookData.title = e.target.value;

                                this.setState({ editBookData });
                            }} />
                        </FormGroup>
                        <FormGroup>
                            <Label for="publisher">Publisher</Label>
                            <Input id="publisher" value={this.state.editBookData.publisher} onChange={(e) => {
                                let { editBookData } = this.state;

                                editBookData.publisher = e.target.value;

                                this.setState({ editBookData });
                            }} />
                        </FormGroup>
                        <FormGroup>
                            <Label for="price">Price</Label>
                            <Input id="price" value={this.state.editBookData.price} onChange={(e) => {
                                let { editBookData } = this.state;

                                editBookData.price = e.target.value;

                                this.setState({ editBookData });
                            }} />
                        </FormGroup>
                        <FormGroup>
                            <Label for="availableStock">Available Srock</Label>
                            <Input id="availableStock" value={this.state.editBookData.availableStock} onChange={(e) => {
                                let { editBookData } = this.state;

                                editBookData.availableStock = e.target.value;

                                this.setState({ editBookData });
                            }} />
                        </FormGroup>

                    </ModalBody>
                    <ModalFooter>
                        <Button color="primary" onClick={this.updateBook.bind(this)}>Update Book</Button>{' '}
                        <Button color="secondary" onClick={this.toggleEditBookModal.bind(this)}>Cancel</Button>
                    </ModalFooter>
                </Modal>




                <Table>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>ISBN</th>
                            <th>Title</th>
                            <th>Publisher</th>
                            <th>Price</th>
                            <th>Available Stock</th>
                            <th>Actions</th>
                        </tr>
                    </thead>

                    <tbody>
                        {books}
                    </tbody>
                </Table>
            </div>
        );
    }
}
