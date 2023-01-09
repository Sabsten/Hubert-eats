import express from 'express';
import articlesRouter from './articles';
const stripe = require('stripe')('votre clé secrète');
const routes = express.Router();
routes.use('/articles',(req, res) => {
    // Récupérer les données de la carte de crédit et de la facture à partir du corps de la demande
    const { amount, card } = req.body;
  
    // Créer une intention de paiement
    stripe.paymentIntents.create({
      amount,
      currency: 'EUR',
      payment_method: 'card',
      confirmation_method: 'manual',
      confirm: true,
      capture_method: 'manual',
      payment_method_data: {
        card: {
          number: card.number,
          exp_month: card.exp_month,
          exp_year: card.exp_year,
          cvc: card.cvc
        }
      }
    }).then(intent => {
    }).catch(error => {
    });
  });
export default routes;