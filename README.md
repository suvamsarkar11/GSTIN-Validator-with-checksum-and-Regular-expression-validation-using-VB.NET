# GSTIN-Validator-with-checksum-and-Regular-expression-validation-using-VB.NET
GSTIN Validator with checksum and Regular expression validation using VB.NET

HOW GSIN VALIDATION WORK


The Most important Validation provided by GSTIN Offline Validation Tool is “Check Sum” Validation. This is the heart of this Tool. The geniuses of the tool lie in the fact that first 14 digits of GSTIN are mathematically related to the last digit. Hence we can check offline whether the GSTIN number is correct or not.

This Mathematical relation was closely guarded secret until recently. To know more about how this works, watch the video below.

Apart from the positional validations (mentioned below) and Check Sum Validation mentioned Above, GSTIN Offline Check also provides following validations

    Length of the Number should be 15 Digits
    State Code should be between 01 to 37 or 98

 Following is the list of Positional Validations performed by =AdarshGSTINCheck() Formula

    First 2 (1st, 2nd) Characters Should be Number
    Next 5 (3,4,5,6,7th) Characters should be Letter
    Next 4 (8,9,10,11th) Characters should be Number
    Next 1 (12th) Character should be Letter
    Next 1 (13th) Character can be Number or Letter
    Next 1 (14th) Character should be “Z”
    Next 1 (15th) Character can be either a Number or a Letter (IT IS CALCULATE BY CHECKSUM)

 CHECKSUM ALGORITHM
 
     PLACE VALUES

0:0              
1:1             
 :         
 :          
 :            
8:8           
9:9        
 
A:10
B:11
 :
 :
 :
Y:34
Z:35


STEP 1
>FIND THE PLACE VALUE OF THE DIGIT
>MULTIPLY BY FACTOR

STEP 2
>DEVIDE TO PLACE VALUE NUMBER OF DIGITS
>ADD THE QUOTIENT IN TO REMINDER 

STEP 3
>REPEAT STEP 1 AND STEP 2 FOR ALL DIGITS

STEP 4
>ADD ALL DIGIT VALUES

STEP 5
>MOD OF SUM AND NUMBER OF POSSIBLE DIGITS
>SUBTRACT FROM TOTAL DIGITS
>MOD AGAIN BY TOTAL DIGITS

STEP 6
>FIND THE PLACE VALUE DIGIT FROM ALL DIGITS


