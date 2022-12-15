// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using System;
using System.Collections.Generic;

public class Span
    {
        public int offset { get; set; }
        public int length { get; set; }
    }

    public class Word
    {
        public string content { get; set; }
        public List<double> boundingBox { get; set; }
        public double confidence { get; set; }
        public Span span { get; set; }
    }

    public class Span2
    {
        public int offset { get; set; }
        public int length { get; set; }
    }

    public class Line
    {
        public string content { get; set; }
        public List<double> boundingBox { get; set; }
        public List<Span> spans { get; set; }
    }

    public class Page
    {
        public int pageNumber { get; set; }
        public int angle { get; set; }
        public double width { get; set; }
        public int height { get; set; }
        public string unit { get; set; }
        public List<Word> words { get; set; }
        public List<object> selectionMarks { get; set; }
        public List<Line> lines { get; set; }
        public List<Span> spans { get; set; }
    }

    public class BoundingRegion
    {
        public int pageNumber { get; set; }
        public List<double> boundingBox { get; set; }
    }

    public class Cell
    {
        public string kind { get; set; }
        public int rowIndex { get; set; }
        public int columnIndex { get; set; }
        public int rowSpan { get; set; }
        public int columnSpan { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public List<Span> spans { get; set; }
    }

    public class Table
    {
        public int rowCount { get; set; }
        public int columnCount { get; set; }
        public List<Cell> cells { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public List<Span> spans { get; set; }
    }

    public class ValueCurrency
    {
        public string currencySymbol { get; set; }
        public double amount { get; set; }
    }

    public class AmountDue
    {
        public string type { get; set; }
        public ValueCurrency valueCurrency { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class BillingAddressRecipient
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class CustomerName
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class DueDate
    {
        public string type { get; set; }
        public string valueDate { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class InvoiceDate
    {
        public string type { get; set; }
        public string valueDate { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class InvoiceId
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class InvoiceTotal
    {
        public string type { get; set; }
        public ValueCurrency valueCurrency { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class Amount
    {
        public string type { get; set; }
        public ValueCurrency valueCurrency { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class Description
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class ProductCode
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class Quantity
    {
        public string type { get; set; }
        public int valueNumber { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class UnitPrice
    {
        public string type { get; set; }
        public ValueCurrency valueCurrency { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class ValueObject
    {
        public Amount Amount { get; set; }
        public Description Description { get; set; }
        public ProductCode ProductCode { get; set; }
        public Quantity Quantity { get; set; }
        public UnitPrice UnitPrice { get; set; }
    }

    public class ValueArray
    {
        public string type { get; set; }
        public ValueObject valueObject { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class Items
    {
        public string type { get; set; }
        public List<ValueArray> valueArray { get; set; }
    }

    public class ShippingAddressRecipient
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class SubTotal
    {
        public string type { get; set; }
        public ValueCurrency valueCurrency { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class TotalTax
    {
        public string type { get; set; }
        public ValueCurrency valueCurrency { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class VendorAddress
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class VendorAddressRecipient
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class VendorName
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class Fields
    {
        public AmountDue AmountDue { get; set; }
        public BillingAddressRecipient BillingAddressRecipient { get; set; }
        public CustomerName CustomerName { get; set; }
        public DueDate DueDate { get; set; }
        public InvoiceDate InvoiceDate { get; set; }
        public InvoiceId InvoiceId { get; set; }
        public InvoiceTotal InvoiceTotal { get; set; }
        public Items Items { get; set; }
        public ShippingAddressRecipient ShippingAddressRecipient { get; set; }
        public SubTotal SubTotal { get; set; }
        public TotalTax TotalTax { get; set; }
        public VendorAddress VendorAddress { get; set; }
        public VendorAddressRecipient VendorAddressRecipient { get; set; }
        public VendorName VendorName { get; set; }
    }

    public class Document
    {
        public string docType { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public Fields fields { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class AnalyzeResult
    {
        public string apiVersion { get; set; }
        public string modelId { get; set; }
        public string stringIndexType { get; set; }
        public string content { get; set; }
        public List<Page> pages { get; set; }
        public List<Table> tables { get; set; }
        public List<object> styles { get; set; }
        public List<Document> documents { get; set; }
    }

    public class AzureFormsRecognizerResponse
    {
        public string status { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime lastUpdatedDateTime { get; set; }
        public AnalyzeResult analyzeResult { get; set; }
    }

