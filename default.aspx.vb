
Partial Class _default
    Inherits System.Web.UI.Page

    Protected Sub performCalButton_Click(sender As Object, e As System.EventArgs) Handles performCalButton.Click
        'specify constant values
        Const Interest_calcs_per_year As Integer = 12
        Const payments_per_year As Integer = 12

        'create variables to hold the values entered by the user
        Dim P As Decimal = LoanAmount.Text
        Dim r As Decimal = rate.Text / 100
        Dim t As Decimal = mortgageLength.Text

        Dim ratePerPeriod As Decimal
        ratePerPeriod = r / Interest_calcs_per_year

        Dim payPeriod As Integer
        payPeriod = t * payments_per_year

        Dim annualRate As Decimal
        annualRate = Math.Exp(Interest_calcs_per_year * Math.Log(1 + ratePerPeriod)) - 1

        Dim intPerPayment As Decimal
        intPerPayment = (Math.Exp(Math.Log(annualRate + 1) / payPeriod) - 1) * payPeriod

        'Now compute the total cost of the loan
        Dim intPerMonth As Decimal = intPerPayment / payments_per_year

        Dim costPerMonth As Decimal
        costPerMonth = P * intPerMonth / (1 - Math.Pow(intPerMonth + 1, -payPeriod))

        'Display the results in the results label web control
        result.Text = "Your mortgage payment per month is $" & costPerMonth.ToString("#,####.##")

    End Sub
End Class
