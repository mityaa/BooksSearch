import React, { Component } from 'react'

class TestCompoent extends Component {
static Z = {
	courseContent : [
	'JSX', 'React Props', 'React State',
	'React Lifecycle Methods', 'React Event Handlers',
	'React Router', 'React Hooks', 'Readux',
	'React Context'
	]
}

constructor(props){
	super(props)
	
	// Set initial state
	this.state = {msg : 'React Course', content:''}
	
	// Binding this keyword
	this.handleClick = this.handleClick.bind(this)
}

renderContent(){
	return (
	<ul>
		{this.props.courseContent.map(content => (
		<li>{content}</li>
		))}
	</ul>
	)
}

handleClick(){

	// Changing state
	this.setState({
	msg : 'Course Content',
	content : this.renderContent()
	})
}

render(){
	return (
	<div>
		<h2>Message :</h2>
		

<p>{this.state.msg}</p>


		

<p>{this.state.content}</p>


		
		{/* Set click handler */}
		<button onClick={this.handleClick}>
		Click here to know contents!
		</button>
	</div>
	)
}
}

export default TestCompoent
