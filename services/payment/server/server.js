require("dotenv").config()

const express = require("express")
const app = express()
app.use(express.json())
app.use(express.static("public"))

const stripe = require("stripe")(process.env.STRIPE_SECRET_KEY)
const storeItems = new Map([
    [1, {price : 100, name : 'T-Shirt'}],
    [2, {price : 200, name : 'Pants'}],
    [3, {price : 300, name : 'Shoes'}],
    [4, {price : 400, name : 'Hat'}],

])

app.post('/create-checkout-session', async (req, res) => {
    try {
        const session = await stripe.checkout.sessions.create({
            payment_method_types: ['card'],
            line_items: req.body.items.map(item => {
                return {
                    price_data: {
                        currency: 'usd',
                        product_data: {
                            name: storeItems.get(item.id).name,
                        },
                        unit_amount: storeItems.get(item.id).price,
                    },
                    quantity: item.quantity,
                }
            }),
            mode: 'payment',
            success_url: '${process.env.SERVER_URL}/success.html',
            cancel_url: '${process.env.SERVER_URL}/cancel.html',
        })
        res.json({id : session.id})

    }catch (e) {
        res.status(500).json({error : e.message})
    }
    res.json({url : session.url})
})

app.listen(3000)