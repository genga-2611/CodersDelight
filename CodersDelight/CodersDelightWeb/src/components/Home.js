import React from 'react';
import { Link } from 'react-router-dom';
import './Home.css';

function Home() {
  return (
    <div className="home">
      <h1>Welcome to Coders Delight</h1>
      <p>Test your programming skills with our comprehensive assessment platform</p>
      <div className="cta-buttons">
        <Link to="/assessments" className="cta-button">View Assessments</Link>
        <Link to="/register" className="cta-button secondary">Sign Up</Link>
      </div>
    </div>
  );
}

export default Home;