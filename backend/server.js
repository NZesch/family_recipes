const express = require('express');
const { Client } = require('pg');
const cors = require('cors');
const { v4: uuidv4 } = require('uuid');

const app = express();
const port = 8800;
const hostname = '127.0.0.1';

// Middleware
app.use(cors());
app.use(express.json());

const client = new Client({
  user: 'postgres',
  password: 'nataliez5',
  host:'127.0.0.1',
  port: 5432,
  database: 'postgres',
});

client.connect()
  .then(() => console.log('Connected to PostgreSQL'))
  .catch(err => console.error('DB connection error', err));

app.listen(port, hostname, () => {
  console.log(`Server running at http://${hostname}:${port}/`);
});

app.get('/recipes', async (req, res) => {
  try {
    const result = await client.query('SELECT * from recipes;');
    res.json(result.rows);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
})

app.post('/recipes', async (req, res) => {
  const { name, num_instructions } = req.body;
  recipe_id = uuidv4();
  instruction_id = uuidv4();
  try {
    const result = await client.query(
      'INSERT INTO recipes (recipe_id, instruction_id, name, num_instructions) VALUES ($1, $2, $3, $4) RETURNING *',
      [recipe_id, instruction_id, name, num_instructions]
    );



    res.status(201).json(result.rows[0]);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
})

app.delete('/recipes', async (req, res) => {
  try {
    const result = await client.query(
      'DELETE FROM recipes'
    );
    res.json(result.rows);
  } catch (err) {
    res.status(500).json({ error: err.message })
  }
})