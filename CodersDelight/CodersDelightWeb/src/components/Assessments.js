import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './Assessments.css';

function Assessments() {
  const [assessments, setAssessments] = useState([]);

  useEffect(() => {
    // TODO: Replace with actual API endpoint
    const fetchAssessments = async () => {
      try {
        const response = await axios.get('/api/Assessments');
        setAssessments(response.data);
      } catch (error) {
        console.error('Error fetching assessments:', error);
      }
    };

    fetchAssessments();
  }, []);

  return (
    <div className="assessments">
      <h2>Available Assessments</h2>
      <div className="assessments-grid">
        {assessments.map((assessment) => (
          <div key={assessment.id} className="assessment-card">
            <h3>{assessment.title}</h3>
            <p>{assessment.description}</p>
            <div className="assessment-details">
              <span>Difficulty: {assessment.difficulty}</span>
              <span>Duration: {assessment.duration} mins</span>
            </div>
            <button className="start-button">Start Assessment</button>
          </div>
        ))}
      </div>
    </div>
  );
}

export default Assessments;