''CODE FOR GST NUMBER VALIDATION 'START'  
Imports System.Text.RegularExpressions

Dim GSTINFORMAT_REGEX As Regex = New Regex("[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9A-Za-z]{1}[Z]{1}[0-9a-zA-Z]{1}")
Dim GSTN_CODEPOINT_CHARS As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    Public Function validGSTIN(ByVal InputGSTIN As String) As Boolean
        'Method to check if a GSTIN is valid. Checks the GSTIN format and the check digit is valid for the passed input GSTIN
        Dim isValidFormat As Boolean = False
        If (checkPattern(InputGSTIN, GSTINFORMAT_REGEX)) = True Then
            isValidFormat = verifyCheckDigit(InputGSTIN)
        Else
            MsgBox("Please Enter Correct GSTIN", vbInformation)
        End If
        Return isValidFormat
    End Function
    
    Public Function checkPattern(ByVal inputval As String, ByVal regxpatrn As Regex) As Boolean
        Dim result As Boolean = False
        Dim Match As Match = regxpatrn.Match(Trim(inputval))
        If Match.Success Then
            result = True
        Else
            result = False
        End If
        Return result
    End Function

    Public Function verifyCheckDigit(ByVal gstinWCheckDigit As String) As Boolean
        Dim isCDValid As Boolean = False
        Dim newGstninWCheckDigit As String = getGSTINWithCheckDigit(gstinWCheckDigit.Substring(0, gstinWCheckDigit.Length() - 1))

        If (gstinWCheckDigit.Trim().Equals(newGstninWCheckDigit)) Then
            isCDValid = True
        Else
            isCDValid = False
        End If
        Return isCDValid
    End Function



    Public Function getGSTINWithCheckDigit(ByVal gstinWOCheckDigit As String) As String
        Dim factor As Integer = 2
        Dim sum As Integer = 0
        Dim checkCodePoint As Integer = 0
        Dim cpChars() As Char
        Dim inputChars() As Char
        Dim i As Integer = 0
        Dim j As Integer = 0
      
        Try
            If (gstinWOCheckDigit = "") Then
                Throw New Exception("GSTIN supplied for checkdigit calculation is null")
            End If
            cpChars = GSTN_CODEPOINT_CHARS.ToCharArray()
            inputChars = gstinWOCheckDigit.Trim().ToUpper().ToCharArray()


            Dim mode As Integer = CInt(cpChars.Length)
            For i = CInt(inputChars.Length) - 1 To 0 Step -1

                Dim codePoint As Integer = -1
                For j = 0 To CInt(cpChars.Length) - 1 
                    If cpChars(j) = inputChars(i) Then
                        codePoint = j
                    End If
                Next
                Dim digit As Integer = factor * codePoint

                If factor = 2 Then
                    factor = 1
                Else
                    factor = 2
                End If
                digit = Int((digit / mode)) + (digit Mod mode)
                sum += digit

            Next
            checkCodePoint = (mode - (sum Mod mode)) Mod mode
            Return gstinWOCheckDigit & cpChars(checkCodePoint)

        Catch ex As Exception
        Finally
            inputChars = ""
            cpChars = ""
        End Try

    End Function
    ''CODE FOR GST NUMBER VALIDATION 'END' 
